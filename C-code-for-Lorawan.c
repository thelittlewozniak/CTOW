/*    _   _ _ _____ _    _              _____     _ _     ___ ___  _  __
 *   /_\ | | |_   _| |_ (_)_ _  __ _ __|_   _|_ _| | |__ / __|   \| |/ /
 *  / _ \| | | | | | ' \| | ' \/ _` (_-< | |/ _` | | / / \__ \ |) | ' <
 * /_/ \_\_|_| |_| |_||_|_|_||_\__, /__/ |_|\__,_|_|_\_\ |___/___/|_|\_\
 *                             |___/
 *
 * Copyright 2018 AllThingsTalk
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

/*
 * Modified ATT Environmental sensing script by Proximus EnCo
 * Removed a couple of sensors to reduce the number of messages sent
 * The original environmental sensing script can be found in the AllThingsTalk RDK file
 */
 
// Select your preferred method of sending data
#define CONTAINERS

/***************************************************************************/


#include "AirQuality2.h"
//#include "arduino.h"
#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>
#include <ATT_LoRaWAN.h>
#include "keys.h"
#include <MicrochipLoRaModem.h>
#include <SoftwareSerial.h>

#define SERIAL_BAUD 57600

#define debugSerial Serial
#define loraSerial Serial1

#define AirQualityPin A0

#define SEND_EVERY 600000

MicrochipLoRaModem modem(&loraSerial, &debugSerial);
ATTDevice device(&modem, &debugSerial, false, 7000);  // minimum time between 2 messages set at 7000 milliseconds

#ifdef CONTAINERS
  #include <Container.h>
  Container container(device);
#endif

Adafruit_BME280 tph; // I2C
int digitalSensor = 20;  // Digital sensor is connected to pin D20/21
AirQuality2 airqualitysensor;
SoftwareSerial SoftSerial(2, 3);
float soundValue;
float temp;
float hum;
float airqual;
unsigned char buffer[200];
int count=0; 
void setup() 
{
  //SoftSerial.begin(SERIAL_BAUD);
  debugSerial.begin(SERIAL_BAUD);
  debugSerial.begin(SERIAL_BAUD);
  while((!debugSerial) && (millis()) < 10000){}  // wait until the serial bus is available

  loraSerial.begin(modem.getDefaultBaudRate());  // set baud rate of the serial connection to match the modem
  while((!loraSerial) && (millis()) < 10000){}   // wait until the serial bus is available

  while(!device.initABP(DEV_ADDR, APPSKEY, NWKSKEY))
  debugSerial.println("Ready to send data");
  
  debugSerial.println();
  debugSerial.println("-- Environmental Sensing LoRa experiment --");
  debugSerial.println();

  initSensors();
}

bool sensorVal = false;
bool prevButtonState = false;

void loop() 
{
    readSensors();
    displaySensorValues();
    sendSensorValues();
    debugSerial.print("Sleeping for: ");
    debugSerial.println(SEND_EVERY);
    debugSerial.println();
    delay(SEND_EVERY);
    debugSerial.print("ARMED and Ready");
    debugSerial.println();
}
void getGPS() {
  if (SoftSerial.available())                    
    {
        char currentchar = '.';
        while(SoftSerial.available())
        {
          char currentchar = SoftSerial.read();
          if(currentchar == '$') 
           {
            buffer[count++]='$';
            break;
            }
          }
        currentchar = '.';
        while(SoftSerial.available() && currentchar != '*' && currentchar != '$')            
        {
            currentchar=SoftSerial.read();   
            buffer[count++]=currentchar;
            if(count == 200)break;
        }
        if(isGPSGPGGA(buffer) == 1) 
        {
        Serial.write(buffer, count);
        Serial.println("");
        }
        clearBufferArray();                      
        count = 0;                               
    }
}
void clearBufferArray()                     
{
    for (int i=0; i<count;i++)
    { buffer[i]=NULL;}                      
}
int isGPSGPGGA(unsigned char* trameGPS) {
  if(trameGPS[0] == '$' && trameGPS[1] == 'G' && trameGPS[2] == 'P' && trameGPS[3] == 'G' && trameGPS[4] == 'G' && trameGPS[5] == 'A')
    return 1;
  else
    return 0;
  }
void initSensors()
{
  debugSerial.println("Initializing sensors, this can take a few seconds..."); 
  tph.begin();
  debugSerial.println("tph initialized");
  airqualitysensor.init(AirQualityPin);
  // give some time to the sensors to init
  delay(10000);
  debugSerial.println("Done");
}

void readSensors()
{
    debugSerial.println("Start reading sensors");
    debugSerial.println("---------------------");

    airqual=airqualitysensor.getRawData();

    getGPS();
    temp = tph.readTemperature();
    hum = tph.readHumidity();    
}

void process()
{
  while(device.processQueue() > 0)
  {
    debugSerial.print("QueueCount: ");
    debugSerial.println(device.queueCount());
    delay(10000);
  }
}

void sendSensorValues()
{
  #ifdef CONTAINERS
  debugSerial.println("Start sending data to the Proximus EnCo platform");
  debugSerial.println("--------------------------------------------");
  container.addToQueue(airqual, AIR_QUALITY_SENSOR, false); process();
  container.addToQueue(temp, TEMPERATURE_SENSOR, false); process();
  container.addToQueue(hum, HUMIDITY_SENSOR, false); process();
  #endif
}

void displaySensorValues()
{
  debugSerial.print("air quality: ");
  debugSerial.print(airqual);
  debugSerial.println(" ");
      
  debugSerial.print("Temperature: ");
  debugSerial.print(temp);
  debugSerial.println(" °C");
      
  debugSerial.print("Humidity: ");
  debugSerial.print(hum);
	debugSerial.println(" %");
}
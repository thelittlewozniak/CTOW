-- -----------------------------------------------------
-- Table address
-- -----------------------------------------------------

CREATE TABLE  address (
  idaddress INT IDENTITY(1,1) NOT NULL,
  address_street VARCHAR(45) NULL,
  address_number VARCHAR(45) NULL,
  address_cp VARCHAR(45) NULL,
  address_city VARCHAR(45) NULL,
  address_country VARCHAR(45) NULL,
  PRIMARY KEY (idaddress))
-- -----------------------------------------------------
-- Table device
-- -----------------------------------------------------
CREATE TABLE  device (
  iddevice INT IDENTITY(1,1) NOT NULL,
  device_description VARCHAR(45) NULL,
  address_idaddress INT NOT NULL,
  PRIMARY KEY (iddevice),
  INDEX fk_device_address_idx (address_idaddress ASC),
  CONSTRAINT fk_device_address
    FOREIGN KEY (address_idaddress)
    REFERENCES address (idaddress)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
-- -----------------------------------------------------
-- Table type_data
-- -----------------------------------------------------
CREATE TABLE  type_data (
  idtype_data INT NOT NULL,
  type_data_description VARCHAR(45) NULL,
  PRIMARY KEY (idtype_data))
-- -----------------------------------------------------
-- Table data
-- -----------------------------------------------------
CREATE TABLE  data (
  iddata INT IDENTITY(1,1) NOT NULL,
  value_data VARCHAR(45) NULL,
  type_idtype INT NOT NULL,
  device_iddevice INT NOT NULL,
  date_time DATETIME NULL,
  PRIMARY KEY (iddata),
  INDEX fk_data_type1_idx (type_idtype ASC),
  INDEX fk_data_device1_idx (device_iddevice ASC),
  CONSTRAINT fk_data_type1
    FOREIGN KEY (type_idtype)
    REFERENCES type_data (idtype_data)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_data_device1
    FOREIGN KEY (device_iddevice)
    REFERENCES device (iddevice)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
-- -----------------------------------------------------
-- Table type_customer
-- -----------------------------------------------------
CREATE TABLE  type_customer (
  idtype_customer INT IDENTITY(1,1) NOT NULL,
  type_customer_description VARCHAR(45) NULL,
  PRIMARY KEY (idtype_customer))
-- -----------------------------------------------------
-- Table customer
-- -----------------------------------------------------
CREATE TABLE  customer (
  idcustomer INT IDENTITY(1,1) NOT NULL,
  customer_email VARCHAR(45) NULL,
  customer_password VARCHAR(45) NULL,
  type_customer_idtype_customer INT NOT NULL,
  PRIMARY KEY (idcustomer),
  INDEX fk_customer_type_customer1_idx (type_customer_idtype_customer ASC),
  CONSTRAINT fk_customer_type_customer1
    FOREIGN KEY (type_customer_idtype_customer)
    REFERENCES type_customer (idtype_customer)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
-- -----------------------------------------------------
-- Table customer_has_device
-- -----------------------------------------------------
CREATE TABLE  customer_has_device (
  customer_idcustomer INT NOT NULL,
  device_iddevice INT NOT NULL,
  PRIMARY KEY (customer_idcustomer, device_iddevice),
  INDEX fk_customer_has_device_device1_idx (device_iddevice ASC),
  INDEX fk_customer_has_device_customer1_idx (customer_idcustomer ASC),
  CONSTRAINT fk_customer_has_device_customer1
    FOREIGN KEY (customer_idcustomer)
    REFERENCES customer (idcustomer)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_customer_has_device_device1
    FOREIGN KEY (device_iddevice)
    REFERENCES device (iddevice)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)

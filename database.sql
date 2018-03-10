-- -----------------------------------------------------
-- Table adress
-- -----------------------------------------------------

CREATE TABLE  adress (
  idadress INT IDENTITY(1,1) NOT NULL,
  adress_street VARCHAR(45) NULL,
  adress_number VARCHAR(45) NULL,
  adress_cp VARCHAR(45) NULL,
  adress_city VARCHAR(45) NULL,
  adress_country VARCHAR(45) NULL,
  PRIMARY KEY (idadress))
-- -----------------------------------------------------
-- Table device
-- -----------------------------------------------------
CREATE TABLE  device (
  iddevice INT IDENTITY(1,1) NOT NULL,
  device_description VARCHAR(45) NULL,
  adress_idadress INT NOT NULL,
  PRIMARY KEY (iddevice),
  INDEX fk_device_adress_idx (adress_idadress ASC),
  CONSTRAINT fk_device_adress
    FOREIGN KEY (adress_idadress)
    REFERENCES adress (idadress)
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
-- Table type_user
-- -----------------------------------------------------
CREATE TABLE  type_user (
  idtype_user INT IDENTITY(1,1) NOT NULL,
  type_user_description VARCHAR(45) NULL,
  PRIMARY KEY (idtype_user))
-- -----------------------------------------------------
-- Table user
-- -----------------------------------------------------
CREATE TABLE  user (
  iduser INT IDENTITY(1,1) NOT NULL,
  user_email VARCHAR(45) NULL,
  user_password VARCHAR(45) NULL,
  type_user_idtype_user INT NOT NULL,
  PRIMARY KEY (iduser),
  INDEX fk_user_type_user1_idx (type_user_idtype_user ASC),
  CONSTRAINT fk_user_type_user1
    FOREIGN KEY (type_user_idtype_user)
    REFERENCES type_user (idtype_user)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
-- -----------------------------------------------------
-- Table user_has_device
-- -----------------------------------------------------
CREATE TABLE  user_has_device (
  user_iduser INT NOT NULL,
  device_iddevice INT NOT NULL,
  PRIMARY KEY (user_iduser, device_iddevice),
  INDEX fk_user_has_device_device1_idx (device_iddevice ASC),
  INDEX fk_user_has_device_user1_idx (user_iduser ASC),
  CONSTRAINT fk_user_has_device_user1
    FOREIGN KEY (user_iduser)
    REFERENCES user (iduser)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_user_has_device_device1
    FOREIGN KEY (device_iddevice)
    REFERENCES device (iddevice)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)

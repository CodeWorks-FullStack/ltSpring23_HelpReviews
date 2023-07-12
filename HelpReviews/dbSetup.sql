-- Active: 1658189439783@@54.187.169.182@3306@lt_spring23
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture',
  bio VARCHAR(255) COMMENT 'My Life Story...'
);

CREATE TABLE IF NOT EXISTS restaurants(
  id iNt AUTO_INCREMENT NOT NULL PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  imgUrl TEXT,
  description TEXT,
  category VARCHAR(32),
  exposure int NOT NULL DEFAULT 0,
  shutdown TINYINT NOT NULL DEFAULT 0,
  creatorId VARCHAR(255) NOT NULL, 

  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS reports(
  id int AUTO_INCREMENT NOT NULL PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(255) NOT NULL,
  body VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  restaurantId int NOT NULL,
  pictureOfDisgust TEXT,

  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY(restaurantId) REFERENCES restaurants(id) ON DELETE CASCADE
);

INSERT INTO restaurants(creatorId, name, description, imgUrl)
VALUE("63615f44096754f30249d528", "The Black Cauldron", "Potions and Brewskies", "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/51E3FED836F349E27268BFF84BD7A27652EAE28E3948E977D16CDDCEBFEA0766/scale?width=1200&aspectRatio=1.78&format=jpeg");


-- -- DROP LOGIC
DROP Table IF EXISTS reports, restaurants, accounts;
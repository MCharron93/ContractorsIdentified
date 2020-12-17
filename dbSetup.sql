-- CREATE TABLE profiles(
--   id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )

-- ALTER TABLE profiles
-- DROP COLUMN specialty
-- ALTER TABLE profiles
-- DROP COLUMN isLicensed

-- CREATE TABLE contractors(
--      id INT NOT NULL AUTO_INCREMENT,
--     wage INT NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     FOREIGN KEY (creatorId)
--       REFERENCES profiles(id)
--       ON DELETE CASCADE
-- )



-- CREATE TABLE jobs(
--    id INT NOT NULL AUTO_INCREMENT,
--     jobtitle VARCHAR(255) NOT NULL,
--     company VARCHAR(255) NOT NULL,
--     pay INT NOT NULL,
--     benefits TINYINT NOT NULL,
--     PRIMARY KEY (id)
-- )
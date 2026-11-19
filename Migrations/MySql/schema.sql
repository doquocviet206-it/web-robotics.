CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;
CREATE TABLE `Articles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext NOT NULL,
    `Slug` varchar(191) NOT NULL,
    `Category` varchar(191) NOT NULL,
    `Level` longtext NOT NULL,
    `Author` longtext NOT NULL,
    `PublishedDate` longtext NOT NULL,
    `ReadTimeMinutes` int NOT NULL,
    `Summary` longtext NOT NULL,
    `ContentMarkdown` longtext NOT NULL,
    `Tags` longtext NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Documents` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext NOT NULL,
    `Category` varchar(191) NOT NULL,
    `FileSize` longtext NOT NULL,
    `Version` longtext NOT NULL,
    `Description` longtext NOT NULL,
    `TargetAudience` longtext NOT NULL,
    `DownloadOrViewUrl` longtext NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Members` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `Role` longtext NOT NULL,
    `Title` longtext NOT NULL,
    `Specialization` longtext NOT NULL,
    `Bio` longtext NOT NULL,
    `Email` longtext NOT NULL,
    `AvatarUrl` longtext NOT NULL,
    `Highlights` longtext NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Projects` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext NOT NULL,
    `Slug` varchar(191) NOT NULL,
    `Category` varchar(191) NOT NULL,
    `Status` longtext NOT NULL,
    `ShortDescription` longtext NOT NULL,
    `DetailedDescription` longtext NOT NULL,
    `TechStack` longtext NOT NULL,
    `Specifications` longtext NOT NULL,
    `LeadResearcher` longtext NOT NULL,
    `Year` int NOT NULL,
    `ImageUrl` longtext NOT NULL,
    `IsCompletedProduct` tinyint(1) NOT NULL,
    `KeyFeatures` longtext NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Publications` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext NOT NULL,
    `Authors` longtext NOT NULL,
    `JournalOrConference` longtext NOT NULL,
    `Year` int NOT NULL,
    `Doi` longtext NOT NULL,
    `Abstract` longtext NOT NULL,
    `PaperUrl` longtext NOT NULL,
    `CitationRank` longtext NOT NULL,
    `Category` longtext NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `SeedHistory` (
    `Id` int NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (`Id`)
);

CREATE INDEX `IX_Articles_Category` ON `Articles` (`Category`);

CREATE UNIQUE INDEX `IX_Articles_Slug` ON `Articles` (`Slug`);

CREATE INDEX `IX_Documents_Category` ON `Documents` (`Category`);

CREATE INDEX `IX_Projects_Category` ON `Projects` (`Category`);

CREATE UNIQUE INDEX `IX_Projects_Slug` ON `Projects` (`Slug`);

CREATE INDEX `IX_Publications_Year` ON `Publications` (`Year`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20261118084245_InitialMySql', '10.0.12');

COMMIT;


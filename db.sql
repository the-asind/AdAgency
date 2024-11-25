﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Billboards" (
    "BillboardId" integer GENERATED BY DEFAULT AS IDENTITY,
    "RegistrationNumber" text NOT NULL,
    "CityDistrict" text NOT NULL,
    "Address" text NOT NULL,
    "LocationDescription" text,
    "UsefulArea" numeric NOT NULL,
    "RentAmountPerWeek" numeric NOT NULL,
    CONSTRAINT "PK_Billboards" PRIMARY KEY ("BillboardId")
);

CREATE TABLE "Renters" (
    "RenterId" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Status" text NOT NULL,
    "LegalAddress" text NOT NULL,
    "DirectorName" text NOT NULL,
    "DirectorPhone" text NOT NULL,
    "ContactPersonName" text NOT NULL,
    "ContactPersonPhone" text NOT NULL,
    "BankName" text NOT NULL,
    "BankAccountNumber" text NOT NULL,
    "Inn" text NOT NULL,
    "Email" text,
    CONSTRAINT "PK_Renters" PRIMARY KEY ("RenterId")
);

CREATE TABLE "Contracts" (
    "ContractId" integer GENERATED BY DEFAULT AS IDENTITY,
    "ContractNumber" text,
    "SigningDate" timestamp with time zone NOT NULL,
    "AgencyResponsible" text,
    "TotalAmount" numeric NOT NULL,
    "PaymentType" text,
    "AdditionalTerms" text,
    "Status" text NOT NULL,
    "RenterId" integer NOT NULL,
    CONSTRAINT "PK_Contracts" PRIMARY KEY ("ContractId"),
    CONSTRAINT "FK_Contracts_Renters_RenterId" FOREIGN KEY ("RenterId") REFERENCES "Renters" ("RenterId") ON DELETE CASCADE
);

CREATE TABLE "Users" (
    "UserId" integer GENERATED BY DEFAULT AS IDENTITY,
    "Username" text,
    "PasswordHash" text,
    "Role" text NOT NULL,
    "RenterId" integer,
    CONSTRAINT "PK_Users" PRIMARY KEY ("UserId"),
    CONSTRAINT "FK_Users_Renters_RenterId" FOREIGN KEY ("RenterId") REFERENCES "Renters" ("RenterId")
);

CREATE TABLE "AdvertisementWorks" (
    "WorkId" integer GENERATED BY DEFAULT AS IDENTITY,
    "ContractId" integer NOT NULL,
    "WorkDescription" text,
    "WorkCost" numeric NOT NULL,
    CONSTRAINT "PK_AdvertisementWorks" PRIMARY KEY ("WorkId"),
    CONSTRAINT "FK_AdvertisementWorks_Contracts_ContractId" FOREIGN KEY ("ContractId") REFERENCES "Contracts" ("ContractId") ON DELETE CASCADE
);

CREATE TABLE "ContractBillboards" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "ContractId" integer NOT NULL,
    "BillboardId" integer NOT NULL,
    "RentStartDate" timestamp with time zone,
    "RentEndDate" timestamp with time zone,
    "RentAmount" numeric NOT NULL,
    "AdvertisementPhotoLink" text NOT NULL,
    CONSTRAINT "PK_ContractBillboards" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ContractBillboards_Billboards_BillboardId" FOREIGN KEY ("BillboardId") REFERENCES "Billboards" ("BillboardId") ON DELETE CASCADE,
    CONSTRAINT "FK_ContractBillboards_Contracts_ContractId" FOREIGN KEY ("ContractId") REFERENCES "Contracts" ("ContractId") ON DELETE CASCADE
);

CREATE TABLE "AuditLogs" (
    "LogId" integer GENERATED BY DEFAULT AS IDENTITY,
    "UserId" integer NOT NULL,
    "Action" text NOT NULL,
    "TableName" text NOT NULL,
    "RecordId" integer,
    "Version" bytea,
    CONSTRAINT "PK_AuditLogs" PRIMARY KEY ("LogId"),
    CONSTRAINT "FK_AuditLogs_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
);

INSERT INTO "Billboards" ("BillboardId", "Address", "CityDistrict", "LocationDescription", "RegistrationNumber", "RentAmountPerWeek", "UsefulArea")
VALUES (1, 'Address 1', 'District 1', 'Location 1', 'RN1', 100.0, 100.0);
INSERT INTO "Billboards" ("BillboardId", "Address", "CityDistrict", "LocationDescription", "RegistrationNumber", "RentAmountPerWeek", "UsefulArea")
VALUES (2, 'Address 2', 'District 2', 'Location 2', 'RN2', 200.0, 200.0);

INSERT INTO "Renters" ("RenterId", "BankAccountNumber", "BankName", "ContactPersonName", "ContactPersonPhone", "DirectorName", "DirectorPhone", "Email", "Inn", "LegalAddress", "Name", "Status")
VALUES (1, 'Account1', 'Bank1', 'Contact1', 'Phone1', 'Director1', 'Phone1', 'email@1.com', 'Inn1', 'Address1', 'Renter1', 'Status1');
INSERT INTO "Renters" ("RenterId", "BankAccountNumber", "BankName", "ContactPersonName", "ContactPersonPhone", "DirectorName", "DirectorPhone", "Email", "Inn", "LegalAddress", "Name", "Status")
VALUES (2, 'Account2', 'Bank2', 'Contact2', 'Phone2', 'Director2', 'Phone2', NULL, 'Inn2', 'Address2', 'Renter2', 'Status2');

INSERT INTO "Contracts" ("ContractId", "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "RenterId", "SigningDate", "Status", "TotalAmount")
VALUES (1, 'None', 'Agency1', '123456', 'Cash', 1, TIMESTAMPTZ '2024-10-29T21:39:37.2658Z', 'active', 0.0);
INSERT INTO "Contracts" ("ContractId", "AdditionalTerms", "AgencyResponsible", "ContractNumber", "PaymentType", "RenterId", "SigningDate", "Status", "TotalAmount")
VALUES (2, 'None', 'Agency2', '654321', 'Credit', 2, TIMESTAMPTZ '2024-10-29T21:39:37.2658Z', 'cancelled', 0.0);

INSERT INTO "Users" ("UserId", "PasswordHash", "RenterId", "Role", "Username")
VALUES (1, '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, 'admin', 'admin');
INSERT INTO "Users" ("UserId", "PasswordHash", "RenterId", "Role", "Username")
VALUES (2, '87eba76e7f3164534045ba922e7770fb58bbd14ad732bbf5ba6f11cc56989e6e', 2, 'configurator', 'worker');

INSERT INTO "AdvertisementWorks" ("WorkId", "ContractId", "WorkCost", "WorkDescription")
VALUES (1, 1, 1000.0, 'Work 1');
INSERT INTO "AdvertisementWorks" ("WorkId", "ContractId", "WorkCost", "WorkDescription")
VALUES (2, 2, 2000.0, 'Work 2');

INSERT INTO "AuditLogs" ("LogId", "Action", "RecordId", "TableName", "UserId")
VALUES (1, 'Action 1', 1, 'Table 1', 1);
INSERT INTO "AuditLogs" ("LogId", "Action", "RecordId", "TableName", "UserId")
VALUES (2, 'Action 2', 2, 'Table 2', 2);

INSERT INTO "ContractBillboards" ("Id", "AdvertisementPhotoLink", "BillboardId", "ContractId", "RentAmount", "RentEndDate", "RentStartDate")
VALUES (1, 'https://mods.store.gx.me/mod/32027713-3e24-46ea-98d2-708f13991e17/cover/5b8f3267-3ad1-444e-8f75-83bab0a48848/webp-640x360?4b8390341bc39300397de58b9cb17301', 1, 1, 1000.0, TIMESTAMPTZ '2024-11-19T21:39:37.265803Z', TIMESTAMPTZ '2024-10-29T21:39:37.265803Z');
INSERT INTO "ContractBillboards" ("Id", "AdvertisementPhotoLink", "BillboardId", "ContractId", "RentAmount", "RentEndDate", "RentStartDate")
VALUES (2, 'https://avatars.mds.yandex.net/get-mpic/4880383/img_id745194673364714228.jpeg/orig', 2, 2, 2000.0, TIMESTAMPTZ '2024-11-12T21:39:37.265804Z', TIMESTAMPTZ '2024-10-29T21:39:37.265804Z');

CREATE INDEX "IX_AdvertisementWorks_ContractId" ON "AdvertisementWorks" ("ContractId");

CREATE INDEX "IX_AuditLogs_UserId" ON "AuditLogs" ("UserId");

CREATE INDEX "IX_ContractBillboards_BillboardId" ON "ContractBillboards" ("BillboardId");

CREATE INDEX "IX_ContractBillboards_ContractId" ON "ContractBillboards" ("ContractId");

CREATE INDEX "IX_Contracts_RenterId" ON "Contracts" ("RenterId");

CREATE INDEX "IX_Users_RenterId" ON "Users" ("RenterId");

SELECT setval(
    pg_get_serial_sequence('"Billboards"', 'BillboardId'),
    GREATEST(
        (SELECT MAX("BillboardId") FROM "Billboards") + 1,
        nextval(pg_get_serial_sequence('"Billboards"', 'BillboardId'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"Renters"', 'RenterId'),
    GREATEST(
        (SELECT MAX("RenterId") FROM "Renters") + 1,
        nextval(pg_get_serial_sequence('"Renters"', 'RenterId'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"Contracts"', 'ContractId'),
    GREATEST(
        (SELECT MAX("ContractId") FROM "Contracts") + 1,
        nextval(pg_get_serial_sequence('"Contracts"', 'ContractId'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"Users"', 'UserId'),
    GREATEST(
        (SELECT MAX("UserId") FROM "Users") + 1,
        nextval(pg_get_serial_sequence('"Users"', 'UserId'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"AdvertisementWorks"', 'WorkId'),
    GREATEST(
        (SELECT MAX("WorkId") FROM "AdvertisementWorks") + 1,
        nextval(pg_get_serial_sequence('"AdvertisementWorks"', 'WorkId'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"AuditLogs"', 'LogId'),
    GREATEST(
        (SELECT MAX("LogId") FROM "AuditLogs") + 1,
        nextval(pg_get_serial_sequence('"AuditLogs"', 'LogId'))),
    false);
SELECT setval(
    pg_get_serial_sequence('"ContractBillboards"', 'Id'),
    GREATEST(
        (SELECT MAX("Id") FROM "ContractBillboards") + 1,
        nextval(pg_get_serial_sequence('"ContractBillboards"', 'Id'))),
    false);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241029213937_Initial', '9.0.0-preview.3.24172.4');

COMMIT;


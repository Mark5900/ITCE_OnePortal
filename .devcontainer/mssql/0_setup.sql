IF EXISTS (SELECT name FROM sys.databases WHERE name = 'ApplicationDB')
DROP DATABASE ApplicationDB
GO

CREATE DATABASE ApplicationDB;
GO
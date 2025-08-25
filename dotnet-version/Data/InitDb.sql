-- SQLite schema for Doctors and Patients
CREATE TABLE IF NOT EXISTS Doctors (
    Id TEXT PRIMARY KEY,
    Name TEXT NOT NULL,
    Specialty TEXT NOT NULL,
    Email TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Patients (
    Id TEXT PRIMARY KEY,
    Name TEXT NOT NULL,
    Email TEXT NOT NULL,
    DateOfBirth TEXT NOT NULL
);

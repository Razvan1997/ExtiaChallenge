IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ExtiaChallenge')
BEGIN
    CREATE DATABASE ExtiaChallenge;
END;
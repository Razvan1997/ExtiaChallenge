IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tSoldier') AND type in (N'U'))
BEGIN
    CREATE TABLE tSoldier (
        id INT PRIMARY KEY IDENTITY(1,1),
        SoldierName VARCHAR(100)
    );

    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier1');
    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier2');
    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier3');
    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier4');
    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier5');
    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier6');
    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier7');
    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier8');
    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier9');
    INSERT INTO tSoldier (SoldierName) VALUES ('Soldier10');
END;
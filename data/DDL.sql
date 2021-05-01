CREATE TABLE Department
    (
        deptNo CHAR(4) PRIMARY KEY,
        deptName VARCHAR(30)
    );

CREATE TABLE Employee
    (
        empNo CHAR(4) PRIMARY KEY,
        fName VARCHAR(20),
        iName VARCHAR(20),
        address VARCHAR(30),
        DOB DATE,
        sex CHAR(1),
        positionn VARCHAR(30),
        deptNo CHAR(4),
        FOREIGN KEY (deptNo) REFERENCES Department,
        CHECK (sex IN ('M', 'F'))
    );

CREATE TABLE Projectt
    (
        projNo CHAR(4) PRIMARY KEY,
        projName VARCHAR(20),
        deptNo CHAR(4),
        FOREIGN KEY (deptNo) REFERENCES Department
    );

CREATE TABLE WorksOn
    (
        empNo CHAR(4),
        projNo CHAR(4),
        dateWorked DATE,
        hoursWorked INTEGER,
        FOREIGN KEY (empNo) REFERENCES Employee,
        FOREIGN KEY (projNo) REFERENCES Projectt,
        CONSTRAINT PK_D PRIMARY KEY (empNo, projNo, dateWorked)
    );

ALTER TABLE Department ADD mrgEmpNo CHAR(4) DEFAULT NULL;
ALTER TABLE Department ADD FOREIGN KEY (mrgEmpNo) REFERENCES Employee (empNo);
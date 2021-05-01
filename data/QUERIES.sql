SELECT * FROM Employee;
SELECT * FROM Employee WHERE sex = 'F';
SELECT fName, iName, address FROM Employee WHERE positionn = 'Department Manager';
SELECT fName, iName, address FROM Employee WHERE deptNo = 'DP64';
SELECT * FROM Employee WHERE deptNo = (SELECT deptNo from Projectt WHERE projNo = 'PJ16');
SELECT * FROM Employee WHERE (sex='M' AND DOB<'01-jan-1958') OR (sex='F' AND DOB<'01-jan-1963'); 
SELECT * FROM Employee WHERE positionn <> 'Department Manager' AND deptNo = (SELECT deptNo from Department WHERE mrgEmpNo = 'EM12');





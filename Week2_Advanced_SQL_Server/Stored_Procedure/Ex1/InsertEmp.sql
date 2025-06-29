DELIMITER $$
DROP PROCEDURE IF EXISTS sp_InsertEmployee $$

CREATE PROCEDURE sp_InsertEmployee(
    IN emp_id INT,
    IN fname VARCHAR(50),
    IN lname VARCHAR(50),
    IN dept_id INT,
    IN sal DECIMAL(10,2),
    IN join_date DATE
)
BEGIN
    INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (emp_id, fname, lname, dept_id, sal, join_date);
END $$

DELIMITER ;


CALL sp_InsertEmployee(5,'Alice', 'Williams', 2, 6200.00, '2023-08-01');

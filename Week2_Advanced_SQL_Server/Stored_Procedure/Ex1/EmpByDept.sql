DELIMITER $$

DROP PROCEDURE IF EXISTS GetEmployeesByDepartment $$

CREATE PROCEDURE GetEmployeesByDepartment(IN dept_id INT)
BEGIN
    SELECT * FROM Employees
    WHERE DepartmentID = dept_id;
END $$

DELIMITER ;


CALL GetEmployeesByDepartment(2);

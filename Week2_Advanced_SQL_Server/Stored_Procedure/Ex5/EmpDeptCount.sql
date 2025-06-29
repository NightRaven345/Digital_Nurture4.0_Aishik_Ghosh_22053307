DELIMITER $$
DROP PROCEDURE IF EXISTS sp_GetEmployeeCountByDepartment $$

CREATE PROCEDURE sp_GetEmployeeCountByDepartment(IN dept_id INT)
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = dept_id;
END $$

DELIMITER ;

CALL sp_GetEmployeeCountByDepartment(3);
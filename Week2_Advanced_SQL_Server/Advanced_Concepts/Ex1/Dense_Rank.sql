SELECT *
FROM (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRank
    FROM Products
) as ProductRanks
WHERE DenseRank <= 3;

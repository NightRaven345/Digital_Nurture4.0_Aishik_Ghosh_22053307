SELECT *
FROM (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS PriceRank
    FROM Products
) as ProductRanks
WHERE PriceRank <= 3;

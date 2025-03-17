CREATE PROCEDURE GetNextOrderPrediction
AS
BEGIN
    SET NOCOUNT ON;

    WITH OrderDifferences AS (
        SELECT 
            o.custid,
            o.orderdate,
            LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate) AS PreviousOrderDate
        FROM Sales.Orders o
    ),
    OrderIntervals AS (
        SELECT 
            custid,
            orderdate,
            DATEDIFF(DAY, PreviousOrderDate, orderdate) AS DaysBetweenOrders
        FROM OrderDifferences
        WHERE PreviousOrderDate IS NOT NULL
    ),
    AvgOrderIntervals AS (
        SELECT 
            custid,
            AVG(DaysBetweenOrders) AS AvgDaysBetweenOrders
        FROM OrderIntervals
        GROUP BY custid
    )
    SELECT 
        c.companyname AS CustomerName,
        MAX(o.orderdate) AS LastOrderDate,
        DATEADD(DAY, COALESCE(aoi.AvgDaysBetweenOrders, 30), MAX(o.orderdate)) AS NextPredictedOrder
    FROM Sales.Customers c
    JOIN Sales.Orders o ON c.custid = o.custid
    LEFT JOIN AvgOrderIntervals aoi ON c.custid = aoi.custid
    GROUP BY c.companyname, aoi.AvgDaysBetweenOrders
    ORDER BY LastOrderDate DESC;
END;
GO

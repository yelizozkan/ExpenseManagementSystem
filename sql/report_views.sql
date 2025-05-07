
-- View: vw_personal_expense_report
CREATE OR REPLACE VIEW "vw_personal_expense_report" AS
SELECT 
    e."Id" AS "ExpenseId",
    e."UserId" AS "UserId",
    e."Description" AS "ExpenseTitle",
    c."Name" AS "CategoryName",
    e."SubmissionDate" AS "ExpenseDate",
    e."Total" AS "TotalAmount",
    s."Name" AS "Status",
    ex."Id" AS "ExpenditureId",
    ex."Description" AS "ExpenditureDescription",
    ex."Amount" AS "Amount",
    ex."StatusId" AS "StatusId",
    ex."CreatedDate" AS "CreatedDate"
FROM "table"."Expenses" e
JOIN "table"."Categories" c ON e."CategoryId" = c."Id"
JOIN "table"."ExpenseStatuses" s ON e."StatusId" = s."Id"
LEFT JOIN "table"."Expenditures" ex ON ex."ExpenseId" = e."Id";


-- View: vw_payment_density_daily
CREATE OR REPLACE VIEW "vw_payment_density_daily" AS
SELECT 
    DATE(p."PaymentDate") AS "GroupedDate",
    u."FirstName" || ' ' || u."LastName" AS "EmployeeName",
    a."FirstName" || ' ' || a."LastName" AS "ApproverName",
    c."Name" AS "CategoryName",
    SUM(p."Amount") AS "TotalAmount",
    COUNT(p."Id") AS "PaymentCount"
FROM "table"."Payments" p
JOIN "table"."Expenditures" ex ON p."ExpenditureId" = ex."Id"
JOIN "table"."Expenses" e ON ex."ExpenseId" = e."Id"
JOIN "table"."Users" u ON e."UserId" = u."Id"
LEFT JOIN "table"."Users" a ON ex."ApprovedById" = a."Id"
JOIN "table"."Categories" c ON ex."CategoryId" = c."Id"
GROUP BY DATE(p."PaymentDate"), "EmployeeName", "ApproverName", "CategoryName"
ORDER BY DATE(p."PaymentDate");



-- View: vw_payment_density_weekly
CREATE OR REPLACE VIEW "vw_payment_density_weekly" AS
SELECT 
    DATE_TRUNC('week', p."PaymentDate") AS "GroupedDate",
    u."FirstName" || ' ' || u."LastName" AS "EmployeeName",
    a."FirstName" || ' ' || a."LastName" AS "ApproverName",
    c."Name" AS "CategoryName",
    SUM(p."Amount") AS "TotalAmount",
    COUNT(p."Id") AS "PaymentCount"
FROM "table"."Payments" p
JOIN "table"."Expenditures" ex ON p."ExpenditureId" = ex."Id"
JOIN "table"."Expenses" e ON ex."ExpenseId" = e."Id"
JOIN "table"."Users" u ON e."UserId" = u."Id"
LEFT JOIN "table"."Users" a ON ex."ApprovedById" = a."Id"
JOIN "table"."Categories" c ON ex."CategoryId" = c."Id"
GROUP BY DATE_TRUNC('week', p."PaymentDate"), "EmployeeName", "ApproverName", "CategoryName"
ORDER BY DATE_TRUNC('week', p."PaymentDate");



-- View: vw_payment_density_monthly
CREATE OR REPLACE VIEW "vw_payment_density_monthly" AS
SELECT 
    DATE_TRUNC('month', p."PaymentDate") AS "GroupedDate",
    u."FirstName" || ' ' || u."LastName" AS "EmployeeName",
    a."FirstName" || ' ' || a."LastName" AS "ApproverName",
    c."Name" AS "CategoryName",
    SUM(p."Amount") AS "TotalAmount",
    COUNT(p."Id") AS "PaymentCount"
FROM "table"."Payments" p
JOIN "table"."Expenditures" ex ON p."ExpenditureId" = ex."Id"
JOIN "table"."Expenses" e ON ex."ExpenseId" = e."Id"
JOIN "table"."Users" u ON e."UserId" = u."Id"
LEFT JOIN "table"."Users" a ON ex."ApprovedById" = a."Id"
JOIN "table"."Categories" c ON ex."CategoryId" = c."Id"
GROUP BY DATE_TRUNC('month', p."PaymentDate"), "EmployeeName", "ApproverName", "CategoryName"
ORDER BY DATE_TRUNC('month', p."PaymentDate");


-- View: vw_user_expenditure_density_daily
CREATE OR REPLACE VIEW "vw_user_expenditure_density_daily" AS
SELECT 
    DATE(ex."Date") AS "GroupedDate",
    u."FirstName" || ' ' || u."LastName" AS "UserName",
    SUM(ex."Amount") AS "TotalAmount",
    COUNT(ex."Id") AS "ExpenditureCount"
FROM "table"."Expenditures" ex
JOIN "table"."Expenses" e ON ex."ExpenseId" = e."Id"
JOIN "table"."Users" u ON e."UserId" = u."Id"
GROUP BY DATE(ex."Date"), u."FirstName", u."LastName"
ORDER BY DATE(ex."Date");


-- View: vw_user_expenditure_density_weekly
CREATE OR REPLACE VIEW "vw_user_expenditure_density_weekly" AS
SELECT 
    DATE_TRUNC('week', ex."Date") AS "GroupedDate",
    u."FirstName" || ' ' || u."LastName" AS "UserName",
    SUM(ex."Amount") AS "TotalAmount",
    COUNT(ex."Id") AS "ExpenditureCount"
FROM "table"."Expenditures" ex
JOIN "table"."Expenses" e ON ex."ExpenseId" = e."Id"
JOIN "table"."Users" u ON e."UserId" = u."Id"
GROUP BY DATE_TRUNC('week', ex."Date"), u."FirstName", u."LastName"
ORDER BY DATE_TRUNC('week', ex."Date");


-- View: vw_user_expenditure_density_monthly
CREATE OR REPLACE VIEW "vw_user_expenditure_density_monthly" AS
SELECT 
    DATE_TRUNC('month', ex."Date") AS "GroupedDate",
    u."FirstName" || ' ' || u."LastName" AS "UserName",
    SUM(ex."Amount") AS "TotalAmount",
    COUNT(ex."Id") AS "ExpenditureCount"
FROM "table"."Expenditures" ex
JOIN "table"."Expenses" e ON ex."ExpenseId" = e."Id"
JOIN "table"."Users" u ON e."UserId" = u."Id"
GROUP BY DATE_TRUNC('month', ex."Date"), u."FirstName", u."LastName"
ORDER BY DATE_TRUNC('month', ex."Date");


-- View: vw_expenditure_approval_daily_summary
CREATE OR REPLACE VIEW "vw_expenditure_approval_daily_summary" AS
SELECT 
    DATE(ex."Date") AS "Date",
    s."Name" AS "StatusName",
    SUM(ex."Amount") AS "TotalAmount",
    COUNT(ex."Id") AS "Count"
FROM "table"."Expenditures" ex
JOIN "table"."ExpenseStatuses" s ON ex."StatusId" = s."Id"
WHERE ex."StatusId" IN (2, 3)
GROUP BY DATE(ex."Date"), s."Name"
ORDER BY DATE(ex."Date");



-- View: vw_expenditure_approval_weekly_summary
CREATE OR REPLACE VIEW "vw_expenditure_approval_weekly_summary" AS
SELECT 
    DATE_TRUNC('week', ex."Date") AS "Date",
    s."Name" AS "StatusName",
    SUM(ex."Amount") AS "TotalAmount",
    COUNT(ex."Id") AS "Count"
FROM "table"."Expenditures" ex
JOIN "table"."ExpenseStatuses" s ON ex."StatusId" = s."Id"
WHERE ex."StatusId" IN (2, 3)
GROUP BY DATE_TRUNC('week', ex."Date"), s."Name"
ORDER BY DATE_TRUNC('week', ex."Date");


-- View: vw_expenditure_approval_monthly_summary
CREATE OR REPLACE VIEW "vw_expenditure_approval_monthly_summary" AS
SELECT 
    DATE_TRUNC('month', ex."Date") AS "Date",
    s."Name" AS "StatusName",
    SUM(ex."Amount") AS "TotalAmount",
    COUNT(ex."Id") AS "Count"
FROM "table"."Expenditures" ex
JOIN "table"."ExpenseStatuses" s ON ex."StatusId" = s."Id"
WHERE ex."StatusId" IN (2, 3)
GROUP BY DATE_TRUNC('month', ex."Date"), s."Name"
ORDER BY DATE_TRUNC('month', ex."Date");

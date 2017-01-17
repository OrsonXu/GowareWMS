# Introduction
A vanilla warehouse management system based on MySQL. The software is targeted for both client and manager. Client can check in new items into the warehouse, check out by Inventory NO, view/search all of their own existing items in the warehose. Manager can view all of the existing items and records, change the price of the service, alter/add/remove information of warehouses and categories (of any item).
# How to run
- Run `SchemaGeneration\GowareDBGeneration.sql` to generate a schema and insert some born data.
- Set the information of the server in `GoWareWMS\DBConnect.cs` such as id and password.
- Run `GoWareWMS\bin\Debug\GoWareWMS.exe` to explore it!

---
Finished in Dec/2016
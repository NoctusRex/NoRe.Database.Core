
# NoRe.Database.Core

 - https://github.com/NoctusRex/NoRe.Database.Core
 - https://www.nuget.org/packages/NoRe.Database.Core/

## Usage
This project contains classes and interfaces as base for NoRe database wrappers like https://github.com/NoctusRex/NoRe.Database.MySql or https://github.com/NoctusRex/NoRe.Database.SqLite.

## Dependencies

 - .NET Framework 4.8

## Classes
### UML
![uml diagramm](https://raw.githubusercontent.com/NoctusRex/NoRe.Database.Core/master/uml.jpg)
### Description

#### IDatabase

##### Usage
This is the interface all wrapper classes of relational  databases will implement for a unified way of use.
Parameter placeholder start with an "@" followed by the index of the parameter starting at 0. E.g.: @0, @1 ,@2, @... .

This interface implements IDisposable.

##### Functions

 - **int ExecuteNonQuery(string, params object[])**: Executes a sql statement with no result and returns the amount of rows that changed.
 - **T ExecuteScalar< T >(string, params object[])**: Executes a sql statement that only returns one value.
 - **Table ExecuteReader(string, params object[])**: Executes a sql statement that returns multiple values like a "SELECT"- statement.
 -  **void ExecuteTransaction(List< Query > / string, params object[])**: Executes a list of sql statements after starting a transaction. If an error occurs the transaction is rolled back and an exception is thrown. If all statements were executed successfully the transaction is committed.
 - **bool TestConnection(out string)**: Tries to connect to the database and returns true if the connection was successfully created. The out parameter returns an error message if the result is false.

#### Query
##### Usage
Contains a command and its parameters to be used in the ExecuteTransaction function of the database wrapper.

##### Attributes

 - **public string CommandText**: The sql command that will be executed.
 - **public object[] Parameters**: The parameters used to fill the placeholders of the command.

##### Functions

 - **public Query()**: Empty constructor.
 - **public Query(string, params object[])**: Constructor to fill the attributes easily.

#### Table
##### Usage
This class is used to return the result of the ExecuteReader function of a database wrapper.

##### Attributes

 - **public List< Rows > Rows**: The rows of the table.
 - **public DataTable DataTable**: The data table of the sql reader result.

##### Functions

 - **public T GetValue< T >(int, string)**: Returns the value of a column of a row at the specified index and column name. Throws an exception if the index or column name was not found.

#### Row
##### Usage
This class represents a row of the table class.

##### Attributes
 - **public List< Column > Columns**: The columns of the row.

##### Functions

 - **public T GetValue< T >(string)**: Returns the value of a column. Takes the column name as parameter. Throws an exception if the name does not exist.

#### Column
##### Usage
This class represents a column of the row class. 

##### Attributes
 - **public string Key**: The name of the column specified in the select statement.
 - **public object Value**: The value of the column.
 
##### Functions
 - **public Column()**: Empty constructor.
 - **public Column(string, object)**: Constructor to fill the attributes easily.
 - **public T GetValue< T >()**: Returns the "Value" property as T.


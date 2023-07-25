# FractionOperations
A simple calculator to perform basic arithmetic operations on fractions (mixed, proper, improper fractions or whole numbers)
## Prerequisites
1. .Net SDK/Runtime (https://dotnet.microsoft.com/en-us/download)
## Steps to run:
1. Clone this repository locally: Run command:<br>
    <code>git clone https://github.com/baymax1109/FractionCalculator.git</code>
2. Open folder in cmd<br>
    <code>cd FractionCalculator</code>
3. Run program and enter any expression<br>
    <code>dotnet run --project FractionOperations</code>
4. Run tests<br>
    <code>dotnet test TestFractionOps</code>
#### Open same folder in any IDE to view code and test files<br>
To open in VSCode, run: <code>code .</code>

### Valid/Invalid expression formats
1. Valid: -1&2/3, 2/3, 1/1, -40/3 etc.<br>
2. Invalid: 1&-2/3, 2/0, 1/-2, 3&, aa etc.
#!/bin/bash
dacpac="false"
sqlfiles="false"
SApassword=$1
dacpath=$2
sqlpath=$3

echo "SELECT * FROM SYS.DATABASES" | dd of=testsqlconnection.sql
for i in {1..60};
do
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SApassword -d master -i testsqlconnection.sql > /dev/null
    if [ $? -eq 0 ]
    then
        echo "SQL server ready"
        break
    else
        echo "Not ready yet..."
        sleep 1
    fi
done
rm testsqlconnection.sql

for f in $dacpath/*
do
    if [ $f == $dacpath/*".dacpac" ]
    then
        dacpac="true"
        echo "Found dacpac $f"
    fi
done

for f in $sqlpath/*
do
    case $f in
        *.sql)
            sqlfiles="true"
            echo "Found SQL file $f"
            ;;
    esac
done

if [ $sqlfiles == "true" ]
then
    for f in $sqlpath/*
    do
        case $f in
            *.sql)
                echo "Executing $f"
                /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SApassword -d master -i $f
                ;;
        esac
    done
fi

if [ $dacpac == "true" ] 
then
    for f in $dacpath/*
    do
        if [ $f == $dacpath/*".dacpac" ]
        then
            dbname=$(basename $f ".dacpac")
            echo "Deploying dacpac $f"
            /opt/sqlpackage/sqlpackage /Action:Publish /SourceFile:$f /TargetServerName:localhost /TargetDatabaseName:$dbname /TargetUser:sa /TargetPassword:$SApassword
        fi
    done
fi
#!/bin/sh
set -ex

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -i /opt/scripts/constraints_off.sql;
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -i /opt/scripts/create_db.sql;
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d CedekapDb -i /opt/scripts/schema.sql;
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d CedekapDb -i /opt/scripts/seed.sql;
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -i /opt/scripts/constraints_on.sql;
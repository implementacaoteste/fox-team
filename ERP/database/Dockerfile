FROM postgres:15-alpine

ENV POSTGRES_DB=erp
ENV POSTGRES_USER=erpuser
ENV POSTGRES_PASSWORD=erppassword

COPY init.sql /docker-entrypoint-initdb.d/

EXPOSE 5432

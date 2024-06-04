FROM postgres:15-alpine

ENV POSTGRES_DB=gestao_db
ENV POSTGRES_USER=usuario_db
ENV POSTGRES_PASSWORD=senha_db

COPY init.sql /docker-entrypoint-initdb.d/

EXPOSE 5432

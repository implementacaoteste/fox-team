# ERP/frontend/frontend_flutter/Dockerfile

# Primeiro estágio: compilação do Flutter
FROM cirrusci/flutter:stable AS build
WORKDIR /app
COPY . .
RUN flutter build web

# Segundo estágio: preparação do servidor nginx
FROM nginx:alpine
COPY --from=build /app/build/web /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]


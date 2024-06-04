# ERP/frontend/frontend_angular/Dockerfile

FROM node:18

WORKDIR /app

# Copiar o package.json e o package-lock.json
COPY package*.json ./

# Instalar as dependências do projeto
RUN npm install

# Copiar todos os arquivos do projeto para o diretório de trabalho
COPY . .

# Build do projeto Angular
RUN npm run build --prod

# Instalar o servidor HTTP estático para servir a aplicação Angular
RUN npm install -g http-server

# Expor a porta que a aplicação irá rodar
EXPOSE 80

# Comando para iniciar a aplicação Angular
CMD ["http-server", "dist/front-end-angular/browser", "-p", "80", "-a", "0.0.0.0"]

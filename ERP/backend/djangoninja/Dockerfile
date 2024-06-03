FROM python:3.10-slim

WORKDIR /app

# Adicione as dependências necessárias para compilar o mysqlclient
RUN apt-get update && apt-get install -y \
    default-libmysqlclient-dev \
    gcc \
    && rm -rf /var/lib/apt/lists/*

COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD ["uvicorn", "djangoninja:app", "--host", "0.0.0.0", "--port", "8000"]

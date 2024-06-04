.PHONY: build up down logs clear

build:
	docker-compose build

up:
	docker-compose up -d

down:
	clear
	docker-compose down

ps:
	docker ps -a
	docker images

logs:
	docker-compose logs -f

mysql:
	docker exec -it container_db printenv | grep MYSQL # Mostra as variáveis de ambiente
	docker exec -it container_db mysql -u$(DB_USER) -p$(DB_PASSWORD) $(DB_DATABASE)

restart: down build up ps logs

clear:
	rm -rf database/db_mysql



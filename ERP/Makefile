.PHONY: build up down logs clear

build:
	docker image prune -a
	make ps
	# docker-compose build

up:
	docker-compose up --build

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

aspnetcore:
	docker exec -it erp-backend_aspnetcore-1

restart: down up ps logs

clear:
	rm -rf database/db_mysql



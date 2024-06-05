# ERP/Makefile

.PHONY: build up down logs clear

build:
	docker image prune -a
	make ps
	# docker-compose build

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

aspnetcore:
	docker exec -it erp-backend_aspnetcore-1

restart: down up ps logs

clear:
	rm -rf database/db_mysql

install_dotnet:
	sudo apt-get install -y wget apt-transport-https

	wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
	sudo dpkg -i packages-microsoft-prod.deb
	rm packages-microsoft-prod.deb

	sudo apt-get update

	wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
	chmod +x dotnet-install.sh
	./dotnet-install.sh --version 8.0.301

	rm dotnet-install.sh
	
	export PATH=$$PATH:~/.dotnet


all:
	docker build -f .\SimpleJobTrackerAPI/Dockerfile -t web_api .
	docker-compose up
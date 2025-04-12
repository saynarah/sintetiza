# sintetiza

Recursos utilizados:
Angular material icons
TailwindCss
Typescript


Documentação rxjs: https://dev.to/felipedsc/behaviorsubject-para-comunicacao-entre-componentes-3kpj

Subindo alterações de frontendo no azure:

- Criando a imagem:
docker build -t sintetize-frontend:latest .
- Carregando:
docker buildx build --load -t sintetize-frontend:latest .
- Criando container:
docker run -p 8080:80 sintetize-frontend:latest



- Configurando o container frontend para o Azure Container

docker tag sintetize-frontend sintetizecr.azurecr.io/sintetize-frontend
docker push sintetizecr.azurecr.io/sintetize-frontend



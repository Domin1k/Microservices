FROM node:12 AS build

WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH

COPY package.json /app/package.json
RUN npm install
RUN npm install -g @angular/cli@8.3.24

COPY . /app

EXPOSE 4200

CMD ng serve --port 4200 --host 0.0.0.0
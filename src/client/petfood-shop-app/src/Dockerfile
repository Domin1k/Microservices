FROM node:12.7-alpine
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .

EXPOSE 4200
CMD npm start
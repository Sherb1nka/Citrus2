FROM node:latest AS npminstall
WORKDIR /app
COPY package.json .
RUN yarn

FROM node:alpine AS build
WORKDIR /app
COPY --from=npminstall "/app/node_modules" node_modules
COPY . .
RUN yarn build

FROM nginx:alpine
WORKDIR /app
RUN rm -rf /usr/share/nginx/html/*
RUN rm -rf /etc/nginx/conf.d/*
COPY --from=build /app/dist/anime-shop-ui /usr/share/nginx/html
COPY default.conf /etc/nginx/conf.d/
EXPOSE 4200
CMD [ "nginx", "-g", "daemon off;" ]


# COPY  ["./animeShopUI/package*.json", "frontend/"]
# WORKDIR /app/frontend
# RUN ls
# RUN npm i -g @angular/cli
# RUN npm install
# COPY . .
# CMD ["npm", "start"]

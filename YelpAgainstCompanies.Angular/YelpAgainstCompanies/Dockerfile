# Use the official Node.js image as the base image
FROM node:19 as build

# Set the working directory in the container
WORKDIR  /usr/src/app

# Copy package.json and package-lock.json to the container
COPY package*.json ./

# Install project dependencies
RUN npm install -g @angular/cli
RUN npm install

# Copy the entire project to the container
COPY . .

# Expose ports
EXPOSE 4200

# Don't share data with Google and stop them from asking
RUN ng analytics off

CMD [ "ng", "serve", "--host", "0.0.0.0" ]
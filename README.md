# WELCOME TO SIX EYE CINEMA

## Overview

SixEyeCinema is a web-based application designed to manage and browse a cinema's movie listings. This project is built using Microsoft SQL for database management, HTML and CSS for front-end design, and ASP.NET for server-side logic.

## Features

- Browse current movie listings
- View movie details including genres, age ratings, and showtimes
- User authentication and authorization
- Admin panel for managing movie listings and showtimes

## Technologies Used

- **Front-end:** HTML, CSS
- **Back-end:** ASP.NET
- **Database:** Microsoft SQL

## Installation

### Prerequisites

- Visual Studio with ASP.NET development tools
- Microsoft SQL Server

### Steps

1. **Clone the repository:**
    ```sh
    git clone https://github.com/yourusername/sixeyecinema.git
    ```

2. **Open the project in Visual Studio:**
    ```sh
    cd sixeyecinema
    start sixeyecinema.sln
    ```

3. **Set up the database:**
   - Open SQL Server Management Studio.
   - Execute the scripts in the `database` folder to set up the database schema and initial data.

4. **Update the database connection string:**
   - Open `Web.config`.
   - Update the `<connectionStrings>` section with your SQL Server details.

5. **Build and run the project:**
    - Press `F5` in Visual Studio to build and run the application.

## Usage

1. **Browse Movies:**
   - Navigate to the homepage to see the current movie listings.

2. **View Movie Details:**
   - Click on a movie title to view its details, including synopsis, cast, and showtimes.

3. **User Authentication:**
   - Register for an account or log in to access personalized features.

4. **Admin Panel:**
   - Log in as an admin to manage movie listings and showtimes.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Open a pull request.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Contact

- **Author:** [Abdullah Malik](https://github.com/ABDmalik6605)
- **Email:** abdullahmalik@gmail.com

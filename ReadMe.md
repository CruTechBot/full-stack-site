# Full Stack Site

This project is a simple **full-stack web application** used for learning and demonstration purposes.  
It includes a front end built with modern web technologies and a .NET back end connected to a database.

---

## 🖥️ Running the Front End

1. Open a terminal and navigate to the frontend folder:

   ```bash
   cd "Full Stack Site/frontend"
   ```

2. Install dependencies (only required the first time):

   ```bash
   npm install
   ```

3. Start the development server:

   ```bash
   npm run dev
   ```

4. Open the URL shown in the terminal in your browser.

---

## ⚙️ Running the Back End

1. Open a terminal and navigate to the backend folder:

   ```bash
   cd "Full Stack Site/backend"
   ```

2. Run the project:
   - In **VS Code** (with C# extension installed): open the integrated terminal and run:

     ```bash
     dotnet run --project Backend
     ```

3. The backend will start a local server.

---

## 🗃️ Updating the Database (Migrations)

Whenever you make changes to the database project (for example, updating models or schema), you’ll need to create a new migration.

1. Open a terminal and navigate to the backend directory:

   ```bash
   cd "Full Stack Site/backend"
   ```

2. Run the following command (replace `NAME` with a descriptive migration name):

   ```bash
   dotnet ef migrations add NAME --project Database --startup-project Backend
   ```

---

**Happy coding!**

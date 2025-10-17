const express = require('express');
const cors = require('cors');
require('dotenv').config();

const { dbConection } = require('./database/config');

// Init
const app = express();

// Middleware
app.use(cors());
app.use(express.json());

// DB
dbConection();

// Routes
app.use('/api/users', require('./routes/users.routes'));

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`Server running on port: ${PORT}`);
});

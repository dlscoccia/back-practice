/* Route: /api/users */

const { Router } = require('express');
const { check } = require('express-validator');
const {
    getUsers,
    createUsers,
    updateUser,
} = require('../controllers/users.controller');
const { validateFields } = require('../middlewares/validate-field.middleware');

const router = Router();

router.get('/', getUsers);

router.post(
    '/',
    [
        check('name', 'Name is required').not().isEmpty(),
        check('email', 'Email is required').isEmail(),
        check('password', 'Password is required').not().isEmpty(),
        validateFields,
    ],
    createUsers
);

router.put(
    '/:id',
    [
        check('name', 'Name is required').not().isEmpty(),
        check('email', 'Email is required').isEmail(),
        check('role', 'Role is required').not().isEmpty(),
        validateFields,
    ],
    updateUser
);

module.exports = router;

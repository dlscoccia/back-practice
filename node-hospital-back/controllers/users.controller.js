const { response } = require('express');
const bcrypt = require('bcryptjs');
const User = require('../models/user.model');

const getUsers = async (req, res = response) => {
    const users = await User.find({}, 'name email role google');

    res.json({
        ok: true,
        users,
    });
};

const createUsers = async (req, res = response) => {
    const { email, password } = req.body;

    try {
        const userExist = await User.findOne({ email });

        if (userExist) {
            return res.status(400).json({
                ok: false,
                msg: 'Email already used.',
            });
        }

        const user = new User(req.body);

        const salt = bcrypt.genSaltSync();
        user.password = bcrypt.hashSync(password, salt);

        await user.save();

        res.json({
            ok: true,
            user,
        });
    } catch (error) {
        console.log(error);
        res.status(500).json({
            ok: false,
            msg: 'Unexpected error.',
        });
    }
};

const updateUser = async (req, res = response) => {
    const id = req.params.id;

    console.log('id', id);

    try {
        const user = await User.findById(id);

        if (!user) {
            return res.status(400).json({
                ok: false,
                msg: 'No user found',
            });
        }

        const { password, google, email, ...fields } = req.body;

        console.log('email', email);
        console.log('email user', user.email);

        if (user.email !== email) {
            const emailExist = await User.findOne({ email });

            if (emailExist) {
                return res.status(400).json({
                    ok: false,
                    msg: 'Email already used',
                });
            }
        }

        fields.email = email;

        const updatedUser = await User.findByIdAndUpdate(id, fields, {
            new: true,
        });

        res.status(200).json({
            ok: true,
            user: updatedUser,
        });
    } catch (error) {
        console.log(error);
        res.status(500).json({
            ok: false,
            msg: 'Unexpected error.',
        });
    }
};

module.exports = { getUsers, createUsers, updateUser };

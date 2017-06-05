import 'modules/bootstrap/dist/css/bootstrap.min.css'
import 'modules/font-awesome/css/font-awesome.min.css'

import '../template/custom.css'

import React from 'react'

import Routes from './routes'

import Header from '../template/header'
import Content from '../template/content'

export default props => (
    <div>
        <Header />
        <div className='container'>
            <Routes />
        </div>
    </div>
)
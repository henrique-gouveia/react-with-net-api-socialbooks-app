import React from 'react'
import { Router, Route, Redirect, hashHistory } from 'react-router'

import AutorList from '../autor/autor-list'
import AutorForm from '../autor/autor-form'

export default props => (
    <Router history={hashHistory}>
        <Route path='/autor' component={AutorList} />
        <Route path='/autor/form' component={AutorForm} />
        <Redirect from='*' to='/autor' />
    </Router>
)
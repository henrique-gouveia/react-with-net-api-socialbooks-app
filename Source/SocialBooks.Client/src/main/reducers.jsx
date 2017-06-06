import { combineReducers } from 'redux'
import { reducer as formReducer } from 'redux-form'
import AutorReducer from '../autor/autor-reducer'

const rootReducer = combineReducers({
    autor: AutorReducer,
    form: formReducer
})

export default rootReducer
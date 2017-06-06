import { hashHistory } from 'react-router'
import { initialize } from 'redux-form'
import Moment from 'moment'
import axios from 'axios'

import { BASE_URL } from '../main/consts'
import { AUTOR_FORM, ACTION_TYPE_FETCHED } from './autor-consts'

const BASE_URL_AUTOR = BASE_URL + '/autor'
const INITIAL_VALUES = { Nome: '', DtCadastro: Moment(new Date).format('DD/MM/YYYY')}

export function listar() {
    const request = axios.get(BASE_URL_AUTOR)
    
    return {
        type: ACTION_TYPE_FETCHED,
        payload: request
    }
}

export function excluir(autor) {
    return dispatch => {
        axios
            .delete(`${BASE_URL_AUTOR}/${autor.Id}`)
            .then(resp => dispatch(listar()))
    }
}

export function gravar(values) {
    return dispatch => {
        let id = ''
        let method = 'post'

        if (values.Id) {
            id = values.Id
            method = 'put'
        }

        axios[method](`${BASE_URL_AUTOR}/${id}`, values)
            .then(resp => {
                dispatch(listar())
                hashHistory.push('/autor')
            })
    }
}

export function cancelar() {
    return [
        initialize(AUTOR_FORM, INITIAL_VALUES),
        hashHistory.push('/autor'),
    ]
}

export function modificar(autor) {
    return [
        initialize(AUTOR_FORM, autor),
        hashHistory.push('/autor/form'),
    ]
}

export function novo() {
    return [
        initialize(AUTOR_FORM, INITIAL_VALUES),
        hashHistory.push('/autor/form')
    ]
}
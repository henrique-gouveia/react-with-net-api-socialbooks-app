import React from 'react'

export default props => (
    <nav className='nav navbar-inverse navbar-static-top'>
        <div className='container-fluid'>
            <div className='navbar-header'>
                <a className='navbar-brand' href='#/autor'>
                    <i className='fa fa-book'></i> SocialBooks
                </a>
            </div>

            <div id='navbar' className='navbar-collapse collapse'>
                <ul className='nav navbar-nav'>
                    <li><a href='#/autor'>Autor</a></li>
                    <li><a href='#/livro'>Livro</a></li>
                </ul>
            </div>
        </div>
    </nav>
)
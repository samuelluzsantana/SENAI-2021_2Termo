import React from 'react'
import ReactDOM from 'react-dom'
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom'

import './index.css'

import App from './Pages/Home/App'
import NotFound from './Pages/NotFound/notfound'

import reportWebVitals from './reportWebVitals'


const routing = (

  <Router>
    <div>
      <Switch>
        <Route exact path='/' component={App} />
        <Route path='/notfound' component={NotFound} />
        <Redirect to='/notfound' />
      </Switch>
    </div>
  </Router>

)


ReactDOM.render(routing, document.getElementById('root'))


reportWebVitals()

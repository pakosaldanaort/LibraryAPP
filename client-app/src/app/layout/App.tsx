import React, {useState, useEffect, Fragment} from 'react';
import { Container } from 'semantic-ui-react';
import { NavBar } from '../../features/nav/NavBar';
import { IUser } from '../models/user';
import { UserButtonList } from '../../features/users/UserButtonList';
import agent from '../api/agent';


const App = () => {
  const [users, setUsers] = useState<IUser[]>([]);
  
  useEffect(() => {
    agent.User.getUsers()
        .then((response) => {
          setUsers(response)
        });
  }, []);

    return (
      <Fragment>
        <NavBar></NavBar>
        <Container style={{marginTop: '7em'}}>
              <UserButtonList users={users}></UserButtonList>
        </Container>
      </Fragment>
    );
}

export default App;

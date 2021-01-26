import React, { useState } from 'react'
import { Button, Container, Grid } from 'semantic-ui-react'
import { IUser } from '../../app/models/user'
import { LibrarianContainer } from './librarian/LibrarianContainer';
import { NormalUserContainer } from './normaluser/NormalUserContainer';

interface IProps {
    users: IUser[]

}

export const UserButtonList: React.FC<IProps> = ({users}) => {
    const [showUserView, setUserView] = useState(0);
    const [userId, setUserId] = useState(0);
    const switchViews = (view:number) => {
        switch (view) {
            case 1:
                return <LibrarianContainer/>
            case 2:
                return  <NormalUserContainer userId={userId}/>
            default:
                break;
        }
    }
    return (
        <Grid>
            <Grid.Column width={10}>
                {
                    users.map((user) => (
                    <Button key={user.userId} color={user.isLibrerian ? 'red': 'green'} onClick={user.isLibrerian ? () => setUserView(1) :  () => {setUserId(user.userId); setUserView(2); }}>{user.firstName}</Button>
                    ))
                }
                <Container>
                    {switchViews(showUserView)}
                </Container>
            </Grid.Column>
        </Grid>
    )
}

import React from 'react'
import { Container, Icon, Menu } from 'semantic-ui-react'

export const NavBar = () => {
    return (
        <Menu fixed='top' inverted>
            <Container>
                <Menu.Item header>
                <Icon name='book' size='big'/>
                    Library
                </Menu.Item>
            </Container>
        </Menu>
    )
}

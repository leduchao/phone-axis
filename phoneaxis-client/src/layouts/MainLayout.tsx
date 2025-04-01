import { ContactsFilled, HomeFilled, ShopFilled } from '@ant-design/icons'
import { Breadcrumb, Layout } from 'antd'
import { Content, Footer, Header } from 'antd/es/layout/layout'
import Sider from 'antd/es/layout/Sider'
import Menu from 'antd/es/menu/menu'
import React from 'react'

const layoutStyle: React.CSSProperties = {
  height: '100vh',
  // padding: '10px',
  // gap: '10px',
  // backgroundColor: 'rgb(165, 165, 165)'
}

const siderStyle: React.CSSProperties = {
  //width: '200px',
  padding: '5px 5px',
  // borderRadius: '8px',
  // backgroundColor: 'black'
}

const headerStyle: React.CSSProperties = {
  textAlign: 'center',
  display: 'flex',
  justifyContent: 'center',
  backgroundColor: 'white',
  boxShadow: '0 0 4px gray',
  position: 'fixed',
  width: '100%'
}

const contentStyle: React.CSSProperties = {
  backgroundColor: 'white',
  margin: '10px 10px 10px',
  padding: '10px',
  borderRadius: '3px',
  // boxShadow: '10px 10px 5px lightblue'
}

const footerStyle: React.CSSProperties = {
  backgroundColor: 'white',
}

const MainLayout = () => {
  return (
    <Layout style={layoutStyle}>
      <Header style={headerStyle}>Header</Header>
      <Layout style={{marginTop: '64px'}}>
        <Sider style={siderStyle}>
          <div className="demo-logo-vertical" />
          <Menu
            theme='dark'
            mode='inline'
            defaultSelectedKeys={['1']}
            items={[
              {
                key: '1',
                icon: <HomeFilled />,
                label: 'Home',
              },
              {
                key: '2',
                icon: <ShopFilled />,
                label: 'Shop',
              },
              {
                key: '3',
                icon: <ContactsFilled />,
                label: 'Contact',
              },
            ]}
          />
        </Sider>
        <Layout style={{backgroundColor: ''}}>
          <Content style={contentStyle}>
            <Breadcrumb
              items={[{ title: 'Home' }, { title: 'List' }, { title: 'App' }]}
              style={{ backgroundColor: 'white', borderRadius: '8px' }}
            />
          </Content>
          <Footer style={footerStyle}>Footer</Footer>
        </Layout>
      </Layout>
    </Layout>
  )
}

export default MainLayout
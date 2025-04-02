import { ContactsFilled, HomeFilled, ShopFilled } from '@ant-design/icons'
import { Breadcrumb, Layout } from 'antd'
import { Content, Footer, Header } from 'antd/es/layout/layout'
import Sider from 'antd/es/layout/Sider'
import Menu from 'antd/es/menu/menu'
import React from 'react'

const layoutStyle: React.CSSProperties = {
  height: '100vh',
}

const siderStyle: React.CSSProperties = {
  padding: '5px 5px',
  overflow: 'auto',
  height: '100vh',
  position: 'fixed',
  insetInlineStart: 0,
  top: 64,
  bottom: 0,
  // scrollbarWidth: 'thin',
  // scrollbarGutter: 'stable',
}

const headerStyle: React.CSSProperties = {
  display: 'flex',
  justifyContent: 'space-between',
  alignItems: 'center',
  backgroundColor: 'white',
  boxShadow: '0 0 4px gray',
  position: 'fixed',
  width: '100%'
}

const contentStyle: React.CSSProperties = {
  backgroundColor: 'white',
  margin: '20px 20px 10px',
  padding: '10px',
  borderRadius: '3px',
}

const footerStyle: React.CSSProperties = {
  backgroundColor: 'white',
}

const MainLayout = () => {
  return (
    <Layout style={layoutStyle}>
      <Header style={headerStyle}>
        <div>Logo</div>
        <div style={{ width: '30%', display: 'flex', justifyContent: '' }}>
          <Menu mode="horizontal" defaultSelectedKeys={['1']}
            items={[
              {
                key: '1',
                label: "Home",
              },
              {
                key: '2',
                label: "Shop",
              },
              {
                key: '3',
                label: "Login",
              },
            ]}
            style={{ display: '', justifyContent: 'flex-end', width: '100%' }}
          />
          {/* <Menu mode="horizontal" defaultSelectedKeys={['']}
            items={[
              {
                key: '5',
                label: "Login",
              },
              {
                key: '6',
                label: "Sign Up",
              },
            ]}
            style={{ display: 'flex', justifyContent: 'flex-end', width: '50%' }}
          /> */}
        </div>
      </Header>
      <Layout style={{ marginTop: '64px' }}>
        <Sider style={siderStyle}>
          <div className="demo-logo-vertical" />
          <Menu theme='dark' mode='inline' defaultSelectedKeys={['1']}
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
        <Layout style={{ backgroundColor: 'linen', height: '1500px', marginLeft: '200px' }}>
          <Breadcrumb
            items={[{ title: 'Home' }, { title: 'List' }, { title: 'App' }]}
            style={{ margin: '20px 20px 0', borderRadius: '8px' }}
          />
          <Content style={contentStyle}></Content>
          <Footer style={footerStyle}>Footer</Footer>
        </Layout>
      </Layout>
    </Layout>
  )
}

export default MainLayout

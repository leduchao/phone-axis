import { Button, Checkbox, Form, Input } from "antd"

type FieldType = {
  username?: string;
  password?: string;
  remember?: string;
};

const Login = () => {
  return (
    <div>
      <Form layout='vertical'>
        <Form.Item<FieldType> label='Username' name='username' rules={[{ required: true, message: 'Please enter your username!' }]}>
          <Input></Input>
        </Form.Item>
        <Form.Item<FieldType> label='Password' name='password' rules={[{ required: true, message: 'Please enter your password!' }]}>
          <Input.Password></Input.Password>
        </Form.Item>
        <Form.Item<FieldType> name='remember' valuePropName='checked' noStyle>
          <Checkbox>Remember me</Checkbox>
        </Form.Item>
        <Form.Item<FieldType> label={null}>
          <Button type='primary' htmlType='submit'>Login</Button>
        </Form.Item>
      </Form>
    </div>
  )
}

export default Login

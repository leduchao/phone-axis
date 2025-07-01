import {
  TextField,
  Typography,
  Box,
  FormControlLabel,
  Checkbox,
  Button,
  Divider,
  Link,
  Card,
  CardContent,
} from "@mui/material";
import GoogleIcon from "@mui/icons-material/Google";
import { ROUTES } from "../../routes";
import { Controller, useForm } from "react-hook-form";
import { SignUpRequest } from "../../models/auth-model";
import { authApi } from "../../apis/auth-api";
import { useNavigate } from "react-router";
import { FieldRules } from "../../constants/field-rules";

function SignUp() {
  const navigate = useNavigate();

  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm<SignUpRequest>({
    defaultValues: {
      firstName: "",
      email: "",
      password: "",
      terms: false,
    },
  });
  const onSubmit = async (data: SignUpRequest) => {
    try {
      const result = await authApi.signUp(data);
      if (result.isSuccess) navigate(ROUTES.SignIn);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div
      style={{
        height: "100vh",
        background: "var(--main-color)",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Card variant="outlined" sx={{ width: "30%" }}>
        <CardContent>
          <Typography
            component="h1"
            variant="h3"
            sx={{
              width: "100%",
              marginBottom: "20px",
              fontWeight: "500",
              textAlign: "center",
              textTransform: "uppercase",
            }}
          >
            Sign up
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit(onSubmit)}
            sx={{ display: "flex", flexDirection: "column", gap: 2 }}
          >
            <Controller
              name="firstName"
              control={control}
              rules={{
                minLength: {
                  value: FieldRules.NAME_MIN_LENGTH,
                  message: `First name must be at least ${FieldRules.NAME_MIN_LENGTH} characters`,
                },
              }}
              render={({ field }) => (
                <TextField
                  {...field}
                  label="Full name"
                  autoComplete="name"
                  fullWidth
                  placeholder="Your name"
                  error={!!errors.firstName}
                  helperText={errors.firstName?.message}
                />
              )}
            ></Controller>
            <Controller
              name="email"
              control={control}
              rules={{
                required: "Email is required",
                pattern: {
                  value: FieldRules.EMAIL_REGEX,
                  message: "Email is not correct format",
                },
              }}
              render={({ field }) => (
                <TextField
                  {...field}
                  label="Email"
                  fullWidth
                  placeholder="your@email.com"
                  autoComplete="email"
                  variant="outlined"
                  error={!!errors.email}
                  helperText={errors.email?.message}
                />
              )}
            ></Controller>
            <Controller
              name="password"
              control={control}
              rules={{
                required: "Password is required",
                minLength: {
                  value: FieldRules.PASSWORD_MIN_LENGTH,
                  message: `Password must be at least ${FieldRules.PASSWORD_MIN_LENGTH} characters`,
                },
              }}
              render={({ field }) => (
                <TextField
                  {...field}
                  label="Password"
                  fullWidth
                  placeholder="••••••"
                  type="password"
                  autoComplete="new-password"
                  variant="outlined"
                  error={!!errors.password}
                  helperText={errors.password?.message}
                />
              )}
            ></Controller>
            <Controller
              name="terms"
              control={control}
              rules={{
                required: "You have to agree with the terms of use",
              }}
              render={({ field }) => (
                <FormControlLabel
                  control={
                    <Checkbox
                      {...field}
                      checked={field.value}
                      color="primary"
                    />
                  }
                  label="I agree to the terms of use"
                  className={errors.terms ? "text-red-600" : ""}
                />
              )}
            ></Controller>
            {errors.terms && (
              <Typography variant="caption" component={"span"} color="error">
                {errors.terms.message}
              </Typography>
            )}
            <Button type="submit" fullWidth variant="contained">
              Sign up
            </Button>
          </Box>
          <Divider sx={{ margin: "10px 0" }}>
            <Typography sx={{ color: "text.secondary" }}>or</Typography>
          </Divider>
          <Box sx={{ display: "flex", flexDirection: "column", gap: 2 }}>
            <Button
              fullWidth
              variant="outlined"
              onClick={() => alert("Sign up with Google")}
              startIcon={<GoogleIcon />}
            >
              Sign up with Google
            </Button>
            <Typography sx={{ textAlign: "center" }}>
              Already have an account?{" "}
              <Link
                href={ROUTES.SignIn}
                sx={{ alignSelf: "center", fontSize: "1rem" }}
              >
                Sign in
              </Link>
            </Typography>
          </Box>
        </CardContent>
      </Card>
    </div>
  );
}

export default SignUp;

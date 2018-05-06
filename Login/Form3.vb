Imports MySql.Data.MySqlClient
Public Class Form3
    Private Sub Akun_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampilAkun()
    End Sub
    Sub bersihkan()
        txtId.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub
    Sub tampilAkun()
        Try
            Call koneksi()
            da = New MySqlDataAdapter("select * from tbl_user order by id_user Asc", conn)
            ds = New DataSet
            da.Fill(ds, "tbl_user")
            dgvAkun.DataSource = ds.Tables("tbl_user")
        Catch ex As Exception

        End Try
    End Sub
    Sub simpanAkun()
        Try
            Call koneksi()
            Dim str As String
            str = "insert into tbl_user ( id_user, username, pass) values ('" & txtId.Text & "','" & txtUsername.Text & "','" & txtPassword.Text & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Akun Berhasil Ditambahkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Insert Akun Baru Gagal Dilakukan" + ex.Message, "Informasi", MessageBoxButtons.OK)
        End Try
    End Sub
    Sub ubahAkun()
        Try
            Call koneksi()
            Dim str As String
            str = "update tbl_user set username = '" & txtUsername.Text & "', pass = '" & txtPassword.Text & "' where id_user =  '" & txtId.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Akun Berhasil Diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Ubah Data Akun Gagal Dilakukan" + ex.Message, "Informasi", MessageBoxButtons.OK)
        End Try
    End Sub
    Sub hapus()
        Try
            Call koneksi()
            Dim str As String
            str = "delete from tbl_user where id_user ='" & txtId.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Akun Berhasil Dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Data Akun Gagal Dihapus" + ex.Message, "Informasi", MessageBoxButtons.OK)
        End Try
    End Sub
    Private Sub btBarang_Click(sender As Object, e As EventArgs) Handles btBarang.Click
        Form2.Visible = True
        Form2.Enabled = True
        Me.Hide()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If MessageBox.Show("Yakin ingin menyimpan data jabatan", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call simpanAkun()
            Call bersihkan()
            Call tampilAkun()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If MessageBox.Show("Yakin ingin mengubah data barang", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call ubahAkun()
            Call bersihkan()
            Call tampilAkun()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Yakin Ingin Menghapus Data Jabatan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call hapus()
            Call bersihkan()
            Call tampilAkun()
        End If
    End Sub

    Private Sub dgvAkun_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAkun.CellContentClick
        Try
            txtId.Text = dgvAkun.Rows(e.RowIndex).Cells(0).Value
            txtUsername.Text = dgvAkun.Rows(e.RowIndex).Cells(1).Value
            txtPassword.Text = dgvAkun.Rows(e.RowIndex).Cells(2).Value

        Catch ex As Exception

        End Try
    End Sub
End Class